import * as metadata from './metadata.g'
import { Model, DataSource, convertToModel, mapToModel } from 'coalesce-vue/lib/model'

export interface ApplicationUser extends Model<typeof metadata.ApplicationUser> {
  applicationUserId: number | null
  name: string | null
}
export class ApplicationUser {
  
  /** Mutates the input object and its descendents into a valid ApplicationUser implementation. */
  static convert(data?: Partial<ApplicationUser>): ApplicationUser {
    return convertToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Maps the input object and its descendents to a new, valid ApplicationUser implementation. */
  static map(data?: Partial<ApplicationUser>): ApplicationUser {
    return mapToModel(data || {}, metadata.ApplicationUser) 
  }
  
  /** Instantiate a new ApplicationUser, optionally basing it on the given data. */
  constructor(data?: Partial<ApplicationUser> | {[k: string]: any}) {
      Object.assign(this, ApplicationUser.map(data || {}));
  }
}


export interface Person extends Model<typeof metadata.Person> {
  personId: number | null
  name: string | null
  birthDate: Date | null
  middleName: string | null
}
export class Person {
  
  /** Mutates the input object and its descendents into a valid Person implementation. */
  static convert(data?: Partial<Person>): Person {
    return convertToModel(data || {}, metadata.Person) 
  }
  
  /** Maps the input object and its descendents to a new, valid Person implementation. */
  static map(data?: Partial<Person>): Person {
    return mapToModel(data || {}, metadata.Person) 
  }
  
  /** Instantiate a new Person, optionally basing it on the given data. */
  constructor(data?: Partial<Person> | {[k: string]: any}) {
      Object.assign(this, Person.map(data || {}));
  }
}


