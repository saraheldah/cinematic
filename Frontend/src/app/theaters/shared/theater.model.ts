import { Guid } from "guid-typescript";
import { Seat } from "src/app/seats/shared/seat.model";

export interface Theater {
    id?: Guid;
    name: string;
    location: string;
    /* seats: Seat[]; */
}
