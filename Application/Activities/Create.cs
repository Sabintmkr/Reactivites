using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
    {
        //Here if we notice command IRequest does not return a value.
        //Because query returns value while command does not return anything
        public class Command : IRequest
        {
            public Activity Activity { get; set; } //this is what we want to receive as a parameter from our API the contract Model
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);
                await _context.SaveChangesAsync();
            }
        }
    }
}