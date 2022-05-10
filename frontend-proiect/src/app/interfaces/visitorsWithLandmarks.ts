import { Landmark } from "./landmark";
import { Visitor } from "./visitor";

export interface VisitorsWithLandmarks {
    visitor: Visitor
    landmarks: Landmark[]
}