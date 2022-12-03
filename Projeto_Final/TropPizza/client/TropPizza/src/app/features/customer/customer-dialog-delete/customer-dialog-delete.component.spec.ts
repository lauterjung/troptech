import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerDialogDeleteComponent } from './customer-dialog-delete.component';

describe('CustomerDialogDeleteComponent', () => {
  let component: CustomerDialogDeleteComponent;
  let fixture: ComponentFixture<CustomerDialogDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomerDialogDeleteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CustomerDialogDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
