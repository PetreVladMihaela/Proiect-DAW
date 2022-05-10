import { Location } from "./location";

export interface LandmarkInfo {
    id: number;
    name: string;
    description: string;
    countryId: number;
    location: Location;
}