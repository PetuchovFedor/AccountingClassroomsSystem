import { Injectable } from "@angular/core";
import { CRUDService } from "../../../shared/services/crud.service";
import { BuildingReadModel } from "../models/building.model";
import { HttpClient } from "@angular/common/http";
import { first, map, Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import {BuildingService as buildingService}  from "../../building/services/building.service"
import { ClassroomService } from "./classroom.service";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";

@Injectable({
    providedIn: 'root'
})
export class BuildingService extends CRUDService<BuildingReadModel> {
    constructor(httpClient: HttpClient) {
        super(httpClient, `${environment.classroomServiceApiURl}${environment.buildingApiName}`)    
    }
}