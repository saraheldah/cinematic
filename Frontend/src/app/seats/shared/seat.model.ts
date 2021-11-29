import { Guid } from "guid-typescript";
import { User } from "src/app/login/shared/user.model";
import { Play } from "src/app/plays/shared/play.model";

export interface Seat {
    id?: Guid;
    row: string;
    number: number;
    status: number;
    playId?: Guid;
    userId?: Guid;
    play?: Play;
    user?: User;
}
