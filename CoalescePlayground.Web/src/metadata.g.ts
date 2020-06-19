import {
  Domain, getEnumMeta, solidify, ModelType, ObjectType,
  PrimitiveProperty, ForeignKeyProperty, PrimaryKeyProperty,
  ModelCollectionNavigationProperty, ModelReferenceNavigationProperty
} from 'coalesce-vue/lib/metadata'


const domain: Domain = { enums: {}, types: {}, services: {} }
export const ApplicationUser = domain.types.ApplicationUser = {
  name: "ApplicationUser",
  displayName: "Application User",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "ApplicationUser",
  get keyProp() { return this.props.applicationUserId }, 
  behaviorFlags: 7,
  props: {
    applicationUserId: {
      name: "applicationUserId",
      displayName: "Application User Id",
      type: "number",
      role: "primaryKey",
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
  },
  methods: {
  },
  dataSources: {
  },
}
export const Person = domain.types.Person = {
  name: "Person",
  displayName: "Person",
  get displayProp() { return this.props.name }, 
  type: "model",
  controllerRoute: "Person",
  get keyProp() { return this.props.personId }, 
  behaviorFlags: 7,
  props: {
    personId: {
      name: "personId",
      displayName: "Person Id",
      type: "number",
      role: "primaryKey",
    },
    name: {
      name: "name",
      displayName: "Name",
      type: "string",
      role: "value",
    },
    birthDate: {
      name: "birthDate",
      displayName: "Birth Date",
      dateKind: "datetime",
      type: "date",
      role: "value",
    },
    middleName: {
      name: "middleName",
      displayName: "Middle Name",
      type: "string",
      role: "value",
    },
  },
  methods: {
    saveWithDelay: {
      name: "saveWithDelay",
      displayName: "Save With Delay",
      transportType: "item",
      httpMethod: "POST",
      params: {
        id: {
          name: "id",
          displayName: "Primary Key",
          role: "value",
          type: "number",
        },
      },
      return: {
        name: "$return",
        displayName: "Result",
        role: "value",
        type: "void",
      },
    },
  },
  dataSources: {
  },
}

interface AppDomain extends Domain {
  enums: {
  }
  types: {
    ApplicationUser: typeof ApplicationUser
    Person: typeof Person
  }
  services: {
  }
}

solidify(domain)

export default domain as AppDomain
