<template>
  <div>
    <ol>
      <div v-for="people in personList.$items">
        <li>
          {{people.name}}
          <button class="crudBtns">&#x270E;</button>
          <button class="crudBtns">&#x1F5D1;</button>
        </li>
          <ul>
            <li><c-display :model="people" for="birthDate" format="M/d/yyyy" /></li>
            <li>Middle Initial: {{people.middleName}}</li>
          </ul>
      </div>
    </ol>
  </div>
</template>

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
  }
</script>