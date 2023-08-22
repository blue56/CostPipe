using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class CostPipeline
    {
        private List<Cost> _cl = new List<Cost>();
        private List<Adjustment> _adjustments = new List<Adjustment>();
        private List<ExchangeRate> _exchangerates = new List<ExchangeRate>();
        private List<Allocation> _allocations = new List<Allocation>();

        public void AddCost(Cost[] Cost)
        {
            _cl.AddRange(Cost);
        }

        public void AddExchanges(ExchangeRate[] ExchangeRates)
        {
            _exchangerates.AddRange(ExchangeRates);
        }

        public void AddAdjustments(Adjustment[] Adjustments)
        {
            _adjustments.AddRange(Adjustments);
        }

        public void AddAllocations(Allocation[] Allocations)
        {
            _allocations.AddRange(Allocations);
        }

        public List<Cost> Run()
        {
            Adjust();
            Exchange();
            Allocate();
            Calculate();

            return _cl;
        }

        public void Adjust()
        {
            foreach (var ci in _cl)
            {
                CostPipe.Adjustment? adjustment = (from it in _adjustments
                                                          where it.Service == ci.Service
                                                          select it).FirstOrDefault();

                if (adjustment != null)
                {
                    Adjusted adjusted = new Adjusted();
                    adjusted.Rate = adjustment.Rate;
                    adjusted.Description = adjustment.Description;
                    adjusted.Amount = ci.Amount * adjustment.Rate;

                    ci.Adjusted = adjusted;
                }
            }
        }

        private void Allocate()
        {
            foreach (var ci in _cl)
            {
                Allocation? allocation = (from it in _allocations
                                          where it.Service == ci.Service
                                          && it.ResourceId == ci.ResourceId
                                          select it).FirstOrDefault();

                if (allocation != null)
                {
                    CostPipe.Allocation cda = new CostPipe.Allocation();
                    cda.CostCenter = allocation.CostCenter;
                    ci.Allocation = cda;
                }
            }
        }

        public void Exchange()
        {
            foreach (var c in _cl)
            {
                var rate = (from it in _exchangerates
                            where it.Service == c.Service
                            && it.From == c.Currency
                            select it).FirstOrDefault();

                if (rate != null)
                {
                    Exchanged exchanged = new Exchanged();
                    exchanged.From = rate.From;
                    exchanged.To = rate.To;
                    exchanged.Rate = rate.Rate;
                    exchanged.ExchangedAmount = c.Amount * exchanged.Rate;

                    c.Exchanged = exchanged;
                }
            }
        }

        public void Calculate()
        {
            foreach (var ci in _cl)
            {
                CostPipe.Total total = new CostPipe.Total();
                if (ci.Adjusted != null)
                {
                    if (ci.Exchanged != null)
                    {
                        total.Amount = ci.Amount + ci.Adjusted.Amount + ci.Exchanged.ExchangedAmount;
                    }
                    else
                    {
                        total.Amount = ci.Amount + ci.Adjusted.Amount;
                    }
                }
                else
                {
                    if (ci.Exchanged != null)
                    {
                        total.Amount = ci.Amount + ci.Exchanged.ExchangedAmount;
                    }
                    else
                    {
                        total.Amount = ci.Amount;
                    }
                }

                ci.Total = total;
            }
        }
    }
}
