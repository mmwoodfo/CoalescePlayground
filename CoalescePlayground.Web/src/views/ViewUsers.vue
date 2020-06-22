<template>

  <div>

    <button v-if="createMode==false" class="crudBtns" @click="enterCreateMode">Add Person</button>
    <button v-if="createMode==true" class="crudBtns" @click="enterCreateMode">Cancel Person</button>

    <div v-if="createMode==true">
      Name: <input class="crudInputs" v-model="person.name" />
      DOB: <c-datetime-picker v-model="person.birthDate" date-kind="date" />
      Middle Name: <input class="crudInputs" v-model="person.middleName" />
      <button class="crudBtns" @click="createPerson()">Submit</button>
    </div>

    <div>
      <p>Filter by name</p>
      <input class="crudInputs" v-model="filter" v-on:keyup.enter="filterByName()" />
    </div>

    <ol>
      <span v-for="people in personList.$items">

        <!--Person Name-->
        <li>
          <span v-if="person.personId == null || person.personId != people.personId">{{people.name}}</span>
          <span v-if="person.personId != null && person.personId == people.personId"><input class="crudInputs" v-on:keyup.enter="updatePerson()" v-model="person.name" /></span>
          <button @click="editPerson(people)" class="crudBtns">&#x270E;</button> <!--edit-->
          <button @click="deletePerson(people)" class="crudBtns">&#x1F5D1;</button> <!--delete-->
          <button v-if="person.personId !=null && person.personId == people.personId" @click="newPerson()" class="crudBtns">X</button> <!--cancel-->
        </li>
          <ul>
            <li>
              <!--Person DOB-->
              <span v-if="person.personId == null || person.personId != people.personId">DOB: <c-display :model="people" for="birthDate" format="M/d/yyyy" /></span>
              <span v-if="person.personId != null && person.personId == people.personId"><c-datetime-picker v-on:keyup.enter="updatePerson()" v-model="person.birthDate" date-kind="date" /></span>
            </li>
            <!--Person Middle Initial-->
            <li>
              <span v-if="person.personId == null || person.personId != people.personId">Middle Name: {{people.middleName}}</span>
              <span v-if="person.personId != null && person.personId == people.personId"><input class="crudInputs" v-on:keyup.enter="updatePerson()" v-model="person.middleName" /></span>
            </li>
          </ul>

      </span>
    </ol>

  </div>

</template>

<script lang="ts">
  import { Vue, Component, Watch, Prop } from "vue-property-decorator";
  import { PersonListViewModel, PersonViewModel } from "@/viewmodels.g";
import { Person } from "../models.g";

  @Component({})
  export default class extends Vue {
    @Prop({ required: true, type: Number })
    id!: number;
    createMode: boolean = false;

    personList = new PersonListViewModel();
    person: PersonViewModel = new PersonViewModel();
    filter: string = "";

    created() {
      this.personList.$load();
    }

    newPerson() {
      this.person = new PersonViewModel();
    }

    enterCreateMode() {
      this.createMode = !this.createMode;
    }
    editPerson(person: PersonViewModel) {
      this.person = person;
    }

    createPerson() {
      this.person.$save().then(() => {
        this.createMode = false;
        this.personList.$load();
        this.newPerson();
      });
    }

    updatePerson() {
      //custom save in Person.cs
      //this.person.saveWithDelay();
      //alert('saved');

      //$save : coalesce save
      this.person.$save().then(() => { this.newPerson(); });
    }

    deletePerson(person: PersonViewModel) {
        person.$delete().then(() => {
        this.personList.$load();
      });
    }

    filterByName() {
      if (this.filter != "" && this.filter != null) {
        this.personList.filterPeople(this.filter).then(result => {
          this.personList.$items = [];
          result.data.object!.forEach((personValue: Person, index: number, array: Person[]) => {
            this.personList.$items.push(new PersonViewModel(personValue));
          });
        });
      } else {
        this.personList.$load();
      }
    }
  }
</script>

<style>
  .crudBtns {
    color: white;
    background-color: #1A76D2;
    padding-left: 5px;
    padding-right: 5px;
    margin: 5px;
    border-radius: 5px;
    box-shadow: 3px 5px 2px rgba(0, 0, 0, 0.5);
  }

  .crudBtns:hover {
    color: white;
    background-color: black;
    box-shadow: none;
  }

  .crudInputs {
    width: 100%;
    padding: 12px 20px;
    margin: 8px 0;
    display: inline-block;
    border: 1px solid #ccc;
    box-sizing: border-box;
    border-radius: 10px;
  }
</style>