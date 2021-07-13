namespace SerenMulti.Northwind {
    export enum OrderShippingState {
        NotShipped = 0,
        Shipped = 1
    }
    Serenity.Decorators.registerEnumType(OrderShippingState, 'SerenMulti.Northwind.OrderShippingState', 'Northwind.OrderShippingState');
}
