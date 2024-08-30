import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";
import { HttpClient } from "@angular/common/http";
import { first, Observable } from "rxjs";

export interface ICRUDService<T extends {id: string}> {
    readonly data$: BehaviorSubject<T[]> 
    readonly baseUrl: string
    getAll(): Observable<T[]>
    add(createModel: any): void
    delete(id: string): void
    update(updateModel: any): void    
}

export abstract class CRUDService<T extends {id: string}> implements ICRUDService<T> {
    data$: BehaviorSubject<T[]> = new BehaviorSubject<T[]>([]);
    readonly baseUrl: string    
    constructor(protected httpclient: HttpClient, baseUrl: string) {
        this.baseUrl = baseUrl
        this.updateData()
        
    }
    public updateData(): void {
        this.getAll()
        .pipe(first())
        .subscribe(data => {            
            this.data$.next(data)
        }
        )
    }
    getAll(): Observable<T[]> {
        return this.httpclient.get<T[]>(`${this.baseUrl}/get-all`)       

    }
    add(createModel: any): void {
        this.httpclient.post<T>(
            `${this.baseUrl}/create`, createModel
        )        
        .pipe(first())
        .subscribe((data) => {
            this.updateData()
        })
    }
    delete(id:string): void {
        this.httpclient.delete(
            `${this.baseUrl}/delete/${id}`
        )
        .pipe(first())
        .subscribe((data) => {
            this.updateData()
        })
    }
    update(updateModel: any): void {        
        this.httpclient.put(
            `${this.baseUrl}/update`, updateModel)
        .pipe(first())
        .subscribe((data) => {
            this.updateData()
        })
    }

}