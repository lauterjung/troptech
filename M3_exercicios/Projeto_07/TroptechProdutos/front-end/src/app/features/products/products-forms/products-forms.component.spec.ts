import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductsFormsComponent } from './products-forms.component';

describe('ProductsFormsComponent', () => {
  let component: ProductsFormsComponent;
  let fixture: ComponentFixture<ProductsFormsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductsFormsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductsFormsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
