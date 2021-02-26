import { TestBed } from '@angular/core/testing';

import { ClientCallsService } from './client-calls.service';

describe('ClientCallsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ClientCallsService = TestBed.get(ClientCallsService);
    expect(service).toBeTruthy();
  });
});
