import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SpaceAllocationToolHttpBaseUrl } from 'src/common/constants';
import { Seat } from 'src/infrastructure-data/model';
import { SeatAllocation } from './model';

@Injectable()
export class AllocationDataService {
    constructor(
        private httpClient: HttpClient
    ) { }

    getSeatsAllocatedToEmployee(employeeId: number, fromDate: string, toDate: string): Promise<Seat[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/allocations/allocatee/${employeeId}`;
        return this.httpClient.get<Seat[]>(url, {params: {
            fromDate: fromDate,
            toDate: toDate
        }}).toPromise();
    }

    getSeatsAllocatedToSubordinatesByEmployee(employeeId: number, fromDate: string, toDate: string): Promise<Seat[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/allocations/allocator/${employeeId}`;
        return this.httpClient.get<Seat[]>(url, {params: {
            fromDate: fromDate,
            toDate: toDate
        }}).toPromise();
    }

    saveAllocations(allocations: SeatAllocation[]) {
        const url = `${SpaceAllocationToolHttpBaseUrl}/allocations`;
        return this.httpClient.post<SeatAllocation[]>(url, allocations).toPromise();
    }

}