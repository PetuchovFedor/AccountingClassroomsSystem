import {ICRUDService } from "../../services/crud.service";
import { BuildingReadModel } from "../../../modules/classroom/models/building.model";
import { ClassroomTypeReadModel } from "../../../modules/classroom/models/classroomType.model"
import { DropDownSize,
    DropDownRounded,
    DropDownFillMode, } from "@progress/kendo-angular-dropdowns";
import { IDropdownListService } from "../../services/dropdown-list.service";

export interface Appearance {
    size: DropDownSize,
    rounded: DropDownRounded,
    fillMode: DropDownFillMode
}

export interface DropdownProps<T extends {id: string, name: string}> {
    appearance: Appearance,
    initValue: T,
    id: string,    
    selectedItemService: IDropdownListService<T>
    dataService: ICRUDService<T>
    style?: Object,
    label?: string,
}