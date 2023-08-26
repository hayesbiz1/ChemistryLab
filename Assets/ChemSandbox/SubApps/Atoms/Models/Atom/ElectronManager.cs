
    using System.Collections.Generic;
    using UnityEngine;

    public class ElectronManager
    {
        enum OrbitalNames
        {
            o1s, o2s, o2px, o2py, o2pz
        }
        
        private Atom atom;
        private int electronCount;

        private Dictionary<OrbitalNames, AbstractOrbital> orbitalDictionary;
        
        public List<AbstractOrbital> orbitalSequentialList;
        
        public ElectronManager(Atom atom)
        {
            this.atom = atom;
            InitOrbitalDictionary();
        }

        private void InitOrbitalDictionary()
        {
            orbitalDictionary = new Dictionary<OrbitalNames, AbstractOrbital>();
            orbitalSequentialList = new List<AbstractOrbital>();

            AddNewOrbital(OrbitalNames.o1s, new Orbital1S());
            AddNewOrbital(OrbitalNames.o2s, new Orbital2S());
            
            AddNewOrbital(OrbitalNames.o2px, new Orbital2Px());
            AddNewOrbital(OrbitalNames.o2py, new Orbital2Py());
            AddNewOrbital(OrbitalNames.o2pz, new Orbital2Pz());
        }

        private void AddNewOrbital(OrbitalNames orbitalName, AbstractOrbital orbital)
        {
            orbitalSequentialList.Add(orbital);
            orbitalDictionary[orbitalName] = orbital;
        }

        public void SetElectronCount(int count)
        {
            electronCount = count;
            ConfigureOrbitals();
        }

        private void ConfigureOrbitals()
        {
            var orbitalFillSequence = new List<OrbitalNames>()
            {
                OrbitalNames.o1s, OrbitalNames.o1s, 
                OrbitalNames.o2s, OrbitalNames.o2s,
                OrbitalNames.o2px, OrbitalNames.o2py, OrbitalNames.o2pz, 
                OrbitalNames.o2px, OrbitalNames.o2py, OrbitalNames.o2pz // Repeat to fill second slot in each orbital.
            };

            var unassignedElectronCount = electronCount;

            // Set orbital electron counts to zero
            foreach (var orbital in orbitalSequentialList)
            {
                orbital.filledElectronSlotCount = 0;
            }
           
            // Assign electrons to orbitals in defined sequence, one electron per iteration, using orbitalFillSequence.
            while (unassignedElectronCount > 0)
            {
                var nextOrbitalName = orbitalFillSequence[0];
                var nextOrbital = orbitalDictionary[nextOrbitalName];
                nextOrbital.filledElectronSlotCount += 1;
                orbitalFillSequence.RemoveAt(0);

                unassignedElectronCount -= 1;
            }

            Debug.Log($"count: {electronCount}=================");
            foreach (var orbital in orbitalSequentialList)
            {
                Debug.Log($"{orbital.name}, {orbital.filledElectronSlotCount}");
            }
        }
    }