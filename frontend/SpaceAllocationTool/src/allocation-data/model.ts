import { Employee } from 'src/employee-data/model';
import { Seat } from 'src/infrastructure-data/model';

export interface SeatAllocation {
    SeatAllocationId?: number;
    Date: string;
    IsBooking?: boolean;
    Seat: Seat;
    Allocatee: Employee;
    Allocator: Employee;
}