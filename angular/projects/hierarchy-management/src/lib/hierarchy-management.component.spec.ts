import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { HierarchyManagementComponent } from './components/hierarchy-management.component';
import { HierarchyManagementService } from '@necnat-abp/hierarchy-management';
import { of } from 'rxjs';

describe('HierarchyManagementComponent', () => {
  let component: HierarchyManagementComponent;
  let fixture: ComponentFixture<HierarchyManagementComponent>;
  const mockHierarchyManagementService = jasmine.createSpyObj('HierarchyManagementService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [HierarchyManagementComponent],
      providers: [
        {
          provide: HierarchyManagementService,
          useValue: mockHierarchyManagementService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HierarchyManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
