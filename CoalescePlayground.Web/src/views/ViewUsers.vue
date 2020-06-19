<template>
  <div>
    <button v-if="createMode==false" class="crudBtns" @click="enterCreateMode">Add Person</button>
    <button v-if="createMode==true" class="crudBtns" @click="enterCreateMode">Cancel</button>
    <div v-if="createMode==true">
      Name: <input v-model="person.name" />
      <!--DOB: <c-datetime-picker v-model="person.birthDate" date-kind="date" />
    Middle Name: <input v-model="person.middleName" />-->
      <button class="crudBtns" @click="createPerson()">+</button>
    </div>
    <ol>
      <span v-for="people in personList.$items">
        <li>
          <span v-if="person.personId == null || person.personId != people.personId">{{people.name}}</span>
          <span v-if="person.personId != null && person.personId == people.personId"><input v-on:keyup.enter="updatePerson()" v-model="person.name" /></span>
          <button @click="editPerson(people)" class="crudBtns">&#x270E;</button> <!--edit-->
          <button @click="deletePerson(people)" class="crudBtns">&#x1F5D1;</button> <!--delete-->
        </li>
        <ul>
          <li>
            <span v-if="person.personId == null || person.personId != people.personId">DOB: <c-display :model="people" for="birthDate" format="M/d/yyyy" /></span>
            <span v-if="person.personId != null && person.personId == people.personId"><c-datetime-picker v-on:keyup.enter="updatePerson()" v-model="person.birthDate" date-kind="date" /></span>
          </li>
          <li>Middle Initial: {{people.middleName}}</li>
        </ul>
      </span>
    </ol>
  </div>
</template>

<script lang="ts">
  import { Vue, Component, Watch, Prop } from "vue-property-decorator";
  import { PersonListViewModel, PersonViewModel } from "@/viewmodels.g";

  @Component({})
  export default class extends Vue {
    @Prop({ required: true, type: Number })
    id!: number;
    createMode: boolean = false;

    personList = new PersonListViewModel();
    person: PersonViewModel = new PersonViewModel();

    created() {
      this.personList.$load();
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
        this.person = new PersonViewModel();
      });
    }

    updatePerson() {
      //custom save in Person.cs
      //this.person.saveWithDelay();
      //alert('saved');

      //$save : coalesce save
      this.person.$save().then(() => { alert('Updated') });
      this.person = new PersonViewModel();
    }

    deletePerson(person: PersonViewModel) {
        person.$delete().then(() => {
        this.personList.$load();
      });
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

  input {
    background-color: lightblue;
  }
</style>