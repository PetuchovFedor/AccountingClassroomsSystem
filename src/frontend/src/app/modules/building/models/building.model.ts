export interface BuildingReadModel {
    id: string,
    name: string,
    address: string,
    floorsCount: number
}

export interface BuildingCreateModel {
    name: string,
    address: string,
    floorsCount: string
}

export interface BuildingUpdateModel {
    id: string,
    name: string,
    address: string,
    floorsCount: number
}
export interface BuildingModel {
    id: string,
    name: string,
    address: string,
    floorsCount: number
}