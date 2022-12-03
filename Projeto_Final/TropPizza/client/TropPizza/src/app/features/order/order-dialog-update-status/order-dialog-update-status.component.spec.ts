import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderDialogUpdateStatusComponent } from './order-dialog-update-status.component';

describe('OrderDialogUpdateStatusComponent', () => {
  let component: OrderDialogUpdateStatusComponent;
  let fixture: ComponentFixture<OrderDialogUpdateStatusComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OrderDialogUpdateStatusComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderDialogUpdateStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
