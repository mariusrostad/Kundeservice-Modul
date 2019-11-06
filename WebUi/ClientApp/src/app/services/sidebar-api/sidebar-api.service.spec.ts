import { TestBed } from '@angular/core/testing';

import { SidebarApiService } from './sidebar-api.service';

describe('SidebarApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SidebarApiService = TestBed.get(SidebarApiService);
    expect(service).toBeTruthy();
  });
});
