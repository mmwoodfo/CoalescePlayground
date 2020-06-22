import * as $metadata from './metadata.g'
import * as $models from './models.g'
import * as $apiClients from './api-clients.g'
import { ViewModel, ListViewModel, ServiceViewModel, DeepPartial, defineProps } from 'coalesce-vue/lib/viewmodel'

export interface ApplicationUserViewModel extends $models.ApplicationUser {
  applicationUserId: number | null;
  name: string | null;
}
export class ApplicationUserViewModel extends ViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, number> implements $models.ApplicationUser  {
  
  constructor(initialData?: DeepPartial<$models.ApplicationUser> | null) {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient(), initialData)
  }
}
defineProps(ApplicationUserViewModel, $metadata.ApplicationUser)

export class ApplicationUserListViewModel extends ListViewModel<$models.ApplicationUser, $apiClients.ApplicationUserApiClient, ApplicationUserViewModel> {
  
  constructor() {
    super($metadata.ApplicationUser, new $apiClients.ApplicationUserApiClient())
  }
}


export interface PersonViewModel extends $models.Person {
  personId: number | null;
  name: string | null;
  birthDate: Date | null;
  middleName: string | null;
  securityLevel: number | null;
  modified: Date | null;
  created: Date | null;
}
export class PersonViewModel extends ViewModel<$models.Person, $apiClients.PersonApiClient, number> implements $models.Person  {
  
  public get saveWithDelay() {
    const saveWithDelay = this.$apiClient.$makeCaller(
      "item", 
      (c) => c.saveWithDelay(this.$primaryKey, ),
      () => ({}),
      (c, args) => c.saveWithDelay(this.$primaryKey, ))
    
    Object.defineProperty(this, 'saveWithDelay', {value: saveWithDelay});
    return saveWithDelay
  }
  
  constructor(initialData?: DeepPartial<$models.Person> | null) {
    super($metadata.Person, new $apiClients.PersonApiClient(), initialData)
  }
}
defineProps(PersonViewModel, $metadata.Person)

export class PersonListViewModel extends ListViewModel<$models.Person, $apiClients.PersonApiClient, PersonViewModel> {
  
  public get filterPeople() {
    const filterPeople = this.$apiClient.$makeCaller(
      "item", 
      (c, filter: string | null) => c.filterPeople(filter),
      () => ({filter: null as string | null, }),
      (c, args) => c.filterPeople(args.filter))
    
    Object.defineProperty(this, 'filterPeople', {value: filterPeople});
    return filterPeople
  }
  
  constructor() {
    super($metadata.Person, new $apiClients.PersonApiClient())
  }
}


const viewModelTypeLookup = ViewModel.typeLookup = {
  ApplicationUser: ApplicationUserViewModel,
  Person: PersonViewModel,
}
const listViewModelTypeLookup = ListViewModel.typeLookup = {
  ApplicationUser: ApplicationUserListViewModel,
  Person: PersonListViewModel,
}
const serviceViewModelTypeLookup = ServiceViewModel.typeLookup = {
}

