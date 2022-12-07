import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderShoppingCartComponent } from './order-shopping-cart.component';

describe('OrderShoppingCartComponent', () => {
  let component: OrderShoppingCartComponent;
  let fixture: ComponentFixture<OrderShoppingCartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderShoppingCartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderShoppingCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
