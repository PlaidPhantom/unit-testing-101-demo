import { Component, EventEmitter, Input, Output, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { of, Subscription } from 'rxjs';

@Component({
  selector: 'app-number-input',
  templateUrl: './number-input.component.html',
  styleUrls: ['./number-input.component.scss']
})
export class NumberInputComponent implements OnInit, OnDestroy {

	form: FormGroup;

	@Input() set value(val: number) {
		this.form.get('val')?.setValue(val);
	}

	get value(): number {
		return Number(this.form.get('val')?.value ?? 0);
	}

	@Output() valueChange: EventEmitter<number> = new EventEmitter<number>();

	subscriptions: Subscription[] = [];

	constructor() {
		this.form = new FormGroup({
			val: new FormControl(0, Validators.required)
		})
	}

	ngOnInit(): void {
		this.subscriptions = [
			(this.form.get('val')?.valueChanges ?? of(0)).subscribe(val => {
				this.valueChange.emit(Number(val));
			})
		]
	}

	ngOnDestroy(): void {
		this.subscriptions.forEach(s => s.unsubscribe());
	}

	increment(): void {
		this.value++;
	}

	decrement(): void {
		this.value--;
	}
}
