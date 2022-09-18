import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Building, Floor, Seat, Wing } from './model';
import { SpaceAllocationToolHttpBaseUrl } from 'src/common/constants';

@Injectable()
export class InfrastructureDataService {
    readonly options = {
        headers: new HttpHeaders().set('access-control-allow-origin', 'http://localhost:8080')
    };

    constructor(
        private httpClient: HttpClient
    ) { }

    getBuildings(): Promise<Building[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/infra/buildings`;
        return this.httpClient.get<Building[]>(url, this.options).toPromise();
    }

    getFloors(buildingId: number): Promise<Floor[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/infra/building/${buildingId}/floors`;
        return this.httpClient.get<Floor[]>(url, this.options).toPromise();
    }

    getWings(floorId: number): Promise<Wing[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/infra/floor/${floorId}/wings`;
        return this.httpClient.get<Wing[]>(url, this.options).toPromise();
    }

    getSeats(wingId: number): Promise<Seat[]> {
        const url = `${SpaceAllocationToolHttpBaseUrl}/infra/wing/${wingId}/seats`;
        return this.httpClient.get<Seat[]>(url, this.options).toPromise();
    }
}