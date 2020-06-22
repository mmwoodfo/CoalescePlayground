import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as qs from 'qs'
import { AxiosClient, ModelApiClient, ServiceApiClient, ItemResult, ListResult } from 'coalesce-vue/lib/api-client'
import { AxiosPromise, AxiosResponse, AxiosRequestConfig } from 'axios'

export class ApplicationUserApiClient extends ModelApiClient<$models.ApplicationUser> {
  constructor() { super($metadata.ApplicationUser) }
}


export class PersonApiClient extends ModelApiClient<$models.Person> {
  constructor() { super($metadata.Person) }
  public saveWithDelay(id: number, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<void>> {
    const $method = this.$metadata.methods.saveWithDelay
    const $params =  {
      id,
    }
    return this.$invoke($method, $params, $config)
  }
  
  public filterPeople(filter: string | null, $config?: AxiosRequestConfig): AxiosPromise<ItemResult<$models.Person[]>> {
    const $method = this.$metadata.methods.filterPeople
    const $params =  {
      filter,
    }
    return this.$invoke($method, $params, $config)
  }
  
}


