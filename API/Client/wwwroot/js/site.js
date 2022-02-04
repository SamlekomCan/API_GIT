// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let animals = [
    { name: "dory", species: "fish", class: { name: "invertebrata" } },
    { name: "simba", species: "cat", class: { name: "mamalia" } },
    { name: "tori", species: "cat", class: { name: "mamalia" } },
    { name: "nemo", species: "fish", class: { name: "invertebrata" } },
    { name: "budi", species: "cat", class: { name: "mamalia" } }
]

for (var i = 0; i < animals.length; i++) {
    if (animals[i].species == "fish") {
        animals[i].class.name = "Non-Mamalia"
    }
}
console.log("ANIMALS")
console.log(animals)

let OnlyCat = []
for (var i = 0; i < animals.length; i++) {
    if (animals[i].species == "cat") {
        OnlyCat.push(animals[i])
    }
}
console.log("ONLYCATS")
console.log(OnlyCat)