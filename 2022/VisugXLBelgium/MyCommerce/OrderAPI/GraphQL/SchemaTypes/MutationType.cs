using System.ComponentModel.DataAnnotations;
// using Common.GraphQL.Extensions;
using HotChocolate.Types;
using OrderAPI.Data;

namespace OrderAPI.GraphQL.SchemaTypes
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Name("Mutation");
            descriptor.Field(x => x.CreateOrder(default, default))
                .Type<NonNullType<OrderType>>()
                .Argument("createOrderInput", x => x.Type<NonNullType<CreateOrderInputType>>());
                // .UsePooledDbContext<OrderContext>();
        }
    }
}