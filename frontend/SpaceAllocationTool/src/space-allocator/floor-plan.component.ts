import { Component, Input, OnInit } from '@angular/core';
import { distinct } from 'src/common/utility-functions';
import { InfrastructureDataService } from 'src/infrastructure-data/infrastructure-data.service';
import { Building, Floor, Seat, Wing } from 'src/infrastructure-data/model';

@Component({
    selector: 'floor-plan',
    templateUrl: './floor-plan.component.html',
    styleUrls: ['./floor-plan.component.scss']
})
export class FloorPlanComponent implements OnInit {
    @Input() fromDate: Date;
    @Input() toDate: Date;

    buildings: Building[] = [];
    floors: Floor[] = [];
    wings: Wing[] = [];
    seats: Seat[] = [];

    selectedBuildingId: number;
    selectedFloorId: number;

    seatsPerWing: { [key: string]: Seat[]};

    selectedSeatIds: Set<number> = new Set<number>();
    
    constructor(
        private infraDataService: InfrastructureDataService
    ) {
    }

    ngOnInit(): void {
        this.loadBuildings();
        this.selectedBuildingId = this.buildings.length && this.buildings[0].BuildingId;
        this.loadFloors(this.selectedBuildingId);
        this.selectedFloorId = this.floors.length && this.floors[0].FloorId;
        this.loadWingsAndSeats(this.selectedFloorId);
    }

    onSelectBuilding(buildingId: number) {
        this.loadFloors(buildingId);
        this.seatsPerWing = {};
        this.selectedSeatIds.clear();
    }
    
    onSelectFloor(floorId: number) {
        this.seatsPerWing = {};
        this.selectedSeatIds.clear();
        this.loadWingsAndSeats(floorId);
    }

    getRows(items: any[] ) {
        if (!items) {
            return null;
        }
        return distinct(items.map(item => item.RowNumber));
    }

    getColumns(items: any[], row: number) {
        if (!items) {
            return null;
        }
        return distinct(items.filter(item => row <= 0 || item.RowNumber === row).map(item => item.ColumnNumber));
    }

    getItemAtLocation(items: any[], row: number, column: number) {
        if (!items) {
            return;
        }
        return items.find(item => item.RowNumber === row && item.ColumnNumber === column);
    }

    getSeatsInAWing(wingId: number) {
        if (!this.seatsPerWing || !this.seatsPerWing[wingId]) {
            return [];
        }
        return this.seatsPerWing[wingId];
    }

    selectSeat(event: any, seat: Seat) {
        // Do not select seat if click is not pressed
        if (!event.buttons) {
            return;
        }

        if (!seat) {
            return;
        }
        this.selectedSeatIds.add(seat.SeatId);
    }

    toggleSelection(seat: Seat) {
        if (!seat) {
            return;
        }
        
        if (this.selectedSeatIds.has(seat.SeatId)) {
            this.selectedSeatIds.delete(seat.SeatId);
            return;
        }
        this.selectedSeatIds.add(seat.SeatId);
    }

    private async loadBuildings() {
        this.buildings = await this.infraDataService.getBuildings();
    }

    private async loadFloors(buildingId: number) {
        this.floors = await this.infraDataService.getFloors(buildingId);
    }

    private async loadWingsAndSeats(floorId: number) {
        this.wings = [];
        this.wings = await this.infraDataService.getWings(floorId);

        const seatsPromise = this.wings.map(wing => this.infraDataService.getSeats(wing.WingId));
        const result = await Promise.all(seatsPromise);

        this.seats = [];
        this.seatsPerWing = {};
        result.forEach(seatCollection => {
            seatCollection.forEach(seat => {
                this.seats.push(seat);
                if (!this.seatsPerWing) {
                    this.seatsPerWing = {};
                }
                if (!this.seatsPerWing[seat.Wing.WingId]) {
                    this.seatsPerWing[seat.Wing.WingId] = [];
                }
                this.seatsPerWing[seat.Wing.WingId].push(seat);
            });
        });
    }
}