import { HttpClient } from "@angular/common/http";
import { CRUDService } from "../../../shared/services/crud.service";
import { AdditionalFieldReadModel } from "../models/additioanlField.model";
import { Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment";

@Injectable({
    providedIn: 'root'
})
export class AdditionalFieldService extends CRUDService<AdditionalFieldReadModel> {
    constructor(httpClient: HttpClient) {
        super(httpClient, `${environment.classroomServiceApiURl}${environment.additionalFieldApiName}`)
    }
}