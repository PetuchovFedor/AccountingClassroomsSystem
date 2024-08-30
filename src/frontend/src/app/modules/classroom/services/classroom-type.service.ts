import { Injectable } from "@angular/core";
import { CRUDService } from "../../../shared/services/crud.service";
import { ClassroomTypeReadModel } from "../models/classroomType.model";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../../../environments/environment";
import { ClassroomService } from "./classroom.service";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";

@Injectable({
    providedIn: 'root'
})
export class ClassroomTypeService extends CRUDService<ClassroomTypeReadModel> {
    constructor(httpClient: HttpClient, classroomService: ClassroomService) {
        super(httpClient, `${environment.classroomServiceApiURl}${environment.classroomTypeApiName}`)
        this.data$
        .pipe(takeUntilDestroyed())
        .subscribe(() => classroomService.updateData())

    }
}