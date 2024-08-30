import { inject, Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../../environments/environment";
import { CRUDService } from "../../../shared/services/crud.service";
import { BuildingReadModel } from "../models/building.model";

@Injectable({
    providedIn: 'root'
})
export class BuildingService extends CRUDService<BuildingReadModel> {
    constructor(httpClient: HttpClient
    ) {
        super(httpClient, `${environment.buildingServiceApiUrl}${environment.buildingApiName}`)
    }

    override delete(id: string): void {
        super.delete(id)
        window.location.reload()
    }
}
