export interface Building {
    BuildingId: number;
    TotalFloors: number;
    BuildingName: string;
}

export interface Floor {
    FloorId: number;
    FloorName: string;
    TotalWings: number;
    Building: Building;
}

export interface Wing {
    WingId: number;
    WingName: string;
    RowNumber: number;
    ColumnNumber: number;
    TotalSeats: number;
    TotalRooms: number;
    Floor: Floor;
}

export interface Seat {
    SeatId: number;
    RowNumber: number;
    ColumnNumber: number;
    Wing: Wing;
}

export interface Room {
    RoomId: number;
    RowNumber: number;
    ColumnNumber: number;
    Wing: Wing;
}