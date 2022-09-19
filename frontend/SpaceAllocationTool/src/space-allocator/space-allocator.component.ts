import { Component } from '@angular/core';
import { AllocationDataService } from 'src/allocation-data/allocation-data.service';
import { SeatAllocation } from 'src/allocation-data/model';
import { formatDate } from 'src/common/utility-functions';
import { EmployeeDataService } from 'src/employee-data/employee-data.service';
import { Employee } from 'src/employee-data/model';
import { Seat } from 'src/infrastructure-data/model';

@Component({
    selector: 'space-allocator',
    templateUrl: './space-allocator.component.html',
    styleUrls: ['./space-allocator.component.scss']
})
export class SpaceAllocatorComponent {
    maxDate: Date = new Date();
    dateRange: Date[] = [new Date(), new Date(this.maxDate.setDate(this.maxDate.getDate() + 3))];

    loggedInUserId: number;
    loggedInUser: Employee;
    subordinates: Employee[];

    selectedEmployeeId: number;
    selectedEmployee: Employee;
    subordinateTeamSizeOfSelectedEmployee: number;

    availableSeats: Seat[];
    allocatedSeats: Seat[];
    
    selectedSeats: {[key: string]: Seat} = {};

    constructor(
        private employeeDataService: EmployeeDataService,
        private allocationService: AllocationDataService
    ) { }

    onSelectEmployee(employeeId: number) {
        this.loadEmployeeDetails(employeeId);
    }

    onUserLoginChange(user: Employee) {
        const userId = user.EmployeeId;
        this.loggedInUser = user;
        this.loggedInUserId = user.EmployeeId;
        this.loadSubordinates(userId);
        this.loadAvailableSeats(userId);
        this.loadAllocatedSeats(userId);
    }

    onSeatSelected(seat: Seat) {
        this.selectedSeats[seat.SeatId] = seat;
    }

    onSeatRemoved(seat: Seat) {
        delete this.selectedSeats[seat.SeatId];
    }

    async saveAllocations() {
        const allocations: SeatAllocation[] = [];
        let startDate = this.dateRange[0];
        let endDate = this.dateRange[1];
        while (startDate.getTime() <= endDate.getTime()) {
            Object.values(this.selectedSeats).forEach(seat => {
                allocations.push({
                    Date: formatDate(startDate),
                    Allocatee: this.selectedEmployee,
                    Allocator: this.loggedInUser,
                    Seat: seat
                });
            })
            startDate = new Date(startDate.setDate(startDate.getDate() + 1));
        }
        console.log(allocations);
        await this.allocationService.saveAllocations(allocations)
    }

    private async loadSubordinates(employeeId: number) {
        this.subordinates = await this.employeeDataService.getSubordinates(employeeId);
    }

    private async loadEmployeeDetails(employeeId: number) {
        this.selectedEmployee = await this.employeeDataService.getEmployeeByEmployeeId(employeeId);
        this.subordinateTeamSizeOfSelectedEmployee = await this.employeeDataService.getSubordinateTeamSize(employeeId);
    }

    private async loadAvailableSeats(employeeId: number) {
        this.availableSeats = await this.allocationService.getSeatsAllocatedToEmployee(employeeId, formatDate(this.dateRange[0]), formatDate(this.dateRange[1]))
    }

    private async loadAllocatedSeats(employeeId: number) {
        this.allocatedSeats = await this.allocationService.getSeatsAllocatedToSubordinatesByEmployee(employeeId, formatDate(this.dateRange[0]), formatDate(this.dateRange[1]));
    }

}