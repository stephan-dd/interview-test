import { TestBed } from '@angular/core/testing';

import { HeroApiService } from './hero-api.service';

describe('HeroApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HeroApiService = TestBed.get(HeroApiService);
    expect(service).toBeTruthy();
  });
});
