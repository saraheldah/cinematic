import { Guid } from "guid-typescript";
import { User } from "src/app/register/shared/user.model";

export interface Seat {
    id?: Guid;
    row: number;
    number: number;
    status: number;
    playId: number;
    userId?: Guid;
}
