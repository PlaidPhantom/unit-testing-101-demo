import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { RandomService } from './random.service';

describe('RandomService', () => {
	beforeEach(() => {
		TestBed.configureTestingModule({
			imports: [
				HttpClientTestingModule
			]
		});
	});

	it('should be created', () => {
		const service = TestBed.inject(RandomService);
		expect(service).toBeTruthy();
	});

	it('should call API for random numbers', done => {
		const service = TestBed.inject(RandomService);
		const httpController = TestBed.inject(HttpTestingController);

		service.getRandomNumbers().subscribe(vals => {
			expect(vals).toEqual([91, 97]);
			done();
		});

		var request = httpController.expectOne(RandomService.URL);
		expect(request.request.method).toBe('GET');
		request.flush('91\n97\n');
	});
});
