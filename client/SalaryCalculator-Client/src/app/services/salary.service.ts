import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface LookupItem {
  id: number;
  name?: string;
  percent?: number;
}

export interface SalaryCalculationInput {
  partTimePercent: number;
  professionalLevel: string;
  managementLevel: string;
  seniorityYears: number;
  lawBonusEligible: boolean;
  lawBonusGroup?: string;
}

export interface SalaryCalculationResult {
  baseSalary: number;
  seniorityBonusPercent: number;
  seniorityBonusAmount: number;
  lawBonusAmount: number;
  salaryBeforeRaise: number;
  raisePercent: number;
  raiseAmount: number;
  salaryAfterRaise: number;
}

@Injectable({ providedIn: 'root' })
export class SalaryService {
  private apiUrl = 'https://localhost:44389/api/SalaryCalculator';

  constructor(private http: HttpClient) {}

  getPartTimePercents(): Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.apiUrl}/part-time-percents`);
  }

  getProfessionalLevels(): Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.apiUrl}/professional-levels`);
  }

  getManagementLevels(): Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.apiUrl}/management-levels`);
  }

  getLawBonusGroups(): Observable<LookupItem[]> {
    return this.http.get<LookupItem[]>(`${this.apiUrl}/law-bonus-groups`);
  }

  calculateSalary(input: SalaryCalculationInput): Observable<SalaryCalculationResult> {
    return this.http.post<SalaryCalculationResult>(`${this.apiUrl}/calculate`, input);
  }
}
