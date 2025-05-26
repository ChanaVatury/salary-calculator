import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, forkJoin, map } from 'rxjs';
import { LookupItem, SalaryCalculationResult, SalaryService } from 'src/app/services/salary.service';

@Component({
  selector: 'app-salary-calculator',
  templateUrl: './salary-calculator.component.html',
  styleUrls: ['./salary-calculator.component.css']
})
export class SalaryCalculatorComponent implements OnInit {
  form: FormGroup;

  partTimePercents$?: Observable<any[]>;
  professionalLevels$?: Observable<any[]>;
  managementLevels$?: Observable<any[]>;
  lawBonusGroups$?: Observable<any[]>;

  result?: SalaryCalculationResult;

  constructor(private fb: FormBuilder, private salaryService: SalaryService) {
    this.form = this.fb.group({
      partTimePercent: [null, Validators.required],
      professionalLevel: [null, Validators.required],
      managementLevel: [null, Validators.required],
      seniorityYears: [0, [Validators.required, Validators.min(0)]],
      lawBonusEligible: [false],
      lawBonusGroup: [{ value: null, disabled: true }]
    });
  }

  ngOnInit() {
    this.partTimePercents$ = this.salaryService.getPartTimePercents().pipe(map(res => res.map(ins => { return { id: ins.id, value: ins?.percent } })));;
    this.professionalLevels$ = this.salaryService.getProfessionalLevels().pipe(map(res => res.map(ins => { return { id: ins.id, value: ins?.name } })));;
    this.managementLevels$ = this.salaryService.getManagementLevels().pipe(map(res => res.map(ins => { return { id: ins.id, value: ins?.name } })));;
    this.lawBonusGroups$ = this.salaryService.getLawBonusGroups().pipe(map(res => res.map(ins => { return { id: ins.id, value: ins?.name } })));

    this.form.get('lawBonusEligible')?.valueChanges.subscribe(enabled => {
      const control = this.form.get('lawBonusGroup');
      if (enabled) control?.enable();
      else control?.disable();
    });

  }

  submit() {
    if (this.form.invalid) return;
    const input = this.form.getRawValue();    console.log(input)

    this.salaryService.calculateSalary(input).subscribe(res => {
      this.result = res;
    });
  }
}
