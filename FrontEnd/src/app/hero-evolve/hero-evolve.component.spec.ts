import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeroEvolveComponent } from './hero-evolve.component';

describe('HeroEvolveComponent', () => {
  let component: HeroEvolveComponent;
  let fixture: ComponentFixture<HeroEvolveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HeroEvolveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HeroEvolveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
