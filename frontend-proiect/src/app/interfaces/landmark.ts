//import { Location } from "./location";

export interface Landmark {
    id: number;
    name: string;
    description: string;
    countryId: number;
    city?: string;
    //location: Location;
}