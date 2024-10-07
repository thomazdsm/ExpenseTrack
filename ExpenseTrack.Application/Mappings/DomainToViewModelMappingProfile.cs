using AutoMapper;
using ExpenseTrack.Application.ViewModels;
using ExpenseTrack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Currency, CurrencyViewModel>();
            CreateMap<ExchangeRate, ExchangeRateViewModel>();
            CreateMap<ExpenseCategory, ExpenseCategoryViewModel>();
            CreateMap<Expense, ExpenseViewModel>();
            CreateMap<Receipt, ReceiptViewModel>();
        }
    }
}
