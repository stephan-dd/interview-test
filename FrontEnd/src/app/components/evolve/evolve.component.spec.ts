import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EvolveComponent } from './evolve.component';

describe('EvolveComponent', () => {
  let component: EvolveComponent;
  let fixture: ComponentFixture<EvolveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EvolveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EvolveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
