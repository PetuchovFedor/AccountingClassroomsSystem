import { HttpClient } from "@angular/common/http";
import { CRUDService } from "../../../shared/services/crud.service";
import { environment } from "../../../../environments/environment";
import { ClassroomReadModel } from "../models/classroom.model";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class ClassroomService extends CRUDService<ClassroomReadModel> {
    constructor(httpClient: HttpClient) {
        super(httpClient, `${environment.classroomServiceApiURl}${environment.classroomApiName}`)        
    }

    override getAll(): Observable<ClassroomReadModel[]> {
        return this.httpclient.get<ClassroomReadModel[]>(`${this.baseUrl}/get-all`)
            .pipe(map((data: any) => {
                return data.map((item: any): ClassroomReadModel => {                    
                    let additionalFields = new Map<string, string>()
                    for (let key of Object.keys(item.additionalFields)) {                        
                        additionalFields.set(key, item.additionalFields[key])
                    }
                    return {
                        id: item.id, 
                        name: item.name,
                        capacity: item.capacity,
                        number: item.number,
                        floor: item.floor,
                        classroomType: item.classroomType,
                        universityBuilding: item.universityBuilding,
                        additionalFields: additionalFields
                    }
                })
            }))
    }
}