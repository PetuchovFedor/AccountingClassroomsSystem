import { BuildingReadModel } from "./building.model";
import { ClassroomTypeReadModel } from "./classroomType.model";

export interface ClassroomReadModel {
    id: string,
    name: string,
    capacity: number,
    number: number,
    floor: number,
    classroomType: ClassroomTypeReadModel,
    universityBuilding: BuildingReadModel,
    additionalFields: Map<string, string>
}

export interface ClassroomUpdateModel {
    id: string,
    name: string,
    capacity: number,
    number: number,
    floor: number,
    classroomTypeId: string,
    universityBuildingId : string
    additionalFields: {[key: string]: string}
}

export interface ClassroomCreateModel {
    name: string,
    capacity: number,
    number: number,
    floor: number,
    classroomTypeId: string,
    universityBuildingId : string
}