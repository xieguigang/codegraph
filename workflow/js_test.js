require(graphQL);

let text = [
    "Water is an inorganic compound with the chemical formula H2O. It is a transparent, tasteless, odorless,[c] and nearly colorless chemical substance, and it is the main constituent of Earth's hydrosphere and the fluids of all known living organisms (in which it acts as a solvent[19]). It is vital for all known forms of life, despite not providing food energy, or organic micronutrients. Its chemical formula, H2O, indicates that each of its molecules contains one oxygen and two hydrogen atoms, connected by covalent bonds. The hydrogen atoms are attached to the oxygen atom at an angle of 104.45°.[20] Water is also the name of the liquid state of H2O at standard temperature and pressure.",
    "Because Earth's environment is relatively close to water's triple point, water exists on Earth as a solid, liquid, and gas.[21] It forms precipitation in the form of rain and aerosols in the form of fog. Clouds consist of suspended droplets of water and ice, its solid state. When finely divided, crystalline ice may precipitate in the form of snow. The gaseous state of water is steam or water vapor.",
    "Water covers about 71% of the Earth's surface, with seas and oceans making up most of the water volume (about 96.5%).[22] Small portions of water occur as groundwater (1.7%), in the glaciers and the ice caps of Antarctica and Greenland (1.7%), and in the air as vapor, clouds (consisting of ice and liquid water suspended in air), and precipitation (0.001%).[23][24] Water moves continually through the water cycle of evaporation, transpiration (evapotranspiration), condensation, precipitation, and runoff, usually reaching the sea.",
    "Water plays an important role in the world economy. Approximately 70% of the freshwater used by humans goes to agriculture.[25] Fishing in salt and fresh water bodies has been, and continues to be, a major source of food for many parts of the world, providing 6.5% of global protein.[26] Much of the long-distance trade of commodities (such as oil, natural gas, and manufactured products) is transported by boats through seas, rivers, lakes, and canals. Large quantities of water, ice, and steam are used for cooling and heating in industry and homes. Water is an excellent solvent for a wide variety of substances, both mineral and organic; as such, it is widely used in industrial processes and in cooking and washing. Water, ice, and snow are also central to many sports and other forms of entertainment, such as swimming, pleasure boating, boat racing, surfing, sport fishing, diving, ice skating, and skiing."
];

let g = graphQL::text_graph(text);

for(let par of g) {
    for(let t in par) {
        console.table(t);
    }
}