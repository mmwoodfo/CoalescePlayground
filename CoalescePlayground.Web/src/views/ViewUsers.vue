<template>
  <div>
    <button class="crudBtns">Add Person</button>
    <ol>
      <span v-for="people in personList.$items">
        <li>
          <span v-if="person.name == null || person.personId != people.personId">{{people.name}}</span>
          <span v-if="person.name != null && person.personId == people.personId"><input v-on:keyup.enter="savePerson()" style="background-color: lightblue;" v-model="person.name" /></span>
          <button @click="editPerson(people)" class="crudBtns">&#x270E;</button> <!--edit-->
          <button class="crudBtns">&#x1F5D1;</button> <!--delete-->
        </li>
        <ul>
          <li>
            <span v-if="person.birthDate == null || person.personId != people.personId"><c-display :model="people" for="birthDate" format="M/d/yyyy" /></span>
            <span v-if="person.birthDate != null && person.personId == people.personId"><c-datetime-picker v-model="person.birthDate" date-kind="date" /></span>
            <!--<input v-on:keyup.enter="savePerson()" style="background-color: lightblue;" v-model="person.name" />-->
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

    personList = new PersonListViewModel();
    person = new PersonViewModel();

    created() {
      this.personList.$load();
    }

    editPerson(person: PersonViewModel) {
      this.person = person;
    }

    savePerson() {
      //custom save in Person.cs
      //this.person.saveWithDelay();
      //alert('saved');

      //$save : coalesce save
      this.person.$save().then(() => { alert('saved') });
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
</style>