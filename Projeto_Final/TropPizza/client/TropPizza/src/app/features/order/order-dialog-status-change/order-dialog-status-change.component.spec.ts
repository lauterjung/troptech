import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDialogStatusChangeComponent } from './order-dialog-status-change.component';

describe('OrderDialogStatusChangeComponent', () => {
  let component: OrderDialogStatusChangeComponent;
  let fixture: ComponentFixture<OrderDialogStatusChangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDialogStatusChangeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderDialogStatusChangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
