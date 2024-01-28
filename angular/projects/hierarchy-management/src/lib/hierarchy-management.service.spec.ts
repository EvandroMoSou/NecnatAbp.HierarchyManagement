import { TestBed } from '@angular/core/testing';
import { HierarchyManagementService } from './services/hierarchy-management.service';
import { RestService } from '@abp/ng.core';

describe('HierarchyManagementService', () => {
  let service: HierarchyManagementService;
  const mockRestService = jasmine.createSpyObj('RestService', ['request']);
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: RestService,
          useValue: mockRestService,
        },
      ],
    });
    service = TestBed.inject(HierarchyManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
