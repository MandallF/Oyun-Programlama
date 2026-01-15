using UnityEngine;

public class DNA_sc : MonoBehaviour
{
    
    List<list> genes = new List<int>();
    int dnalenght =0;
    int maxValues=0;
    public DNA_sc(int lenght, int value){
        dnalenght = lenght;
        maxValues = value;
        SetRandom();
    }
    public SetRandom(){
        genes.Clear();
        for(int i=0; i<dnalenght; i++){
            genes.Add(Random.Range(0,maxValues));
        }
    }
    public void setInt(int pos, int value)
    {
        genes[pos]=value;
    }
    public int getGene(int pos)
    {
        return genes[pos];
    }
    public void Combine(DNA_sc d1, DNA_sc d2)
    {
        for(int i=0; i<dnalenght; i++)
        {
            if (i < dnalenght / 2.0)
            {
                int c = d1.genes[i];
                genes[i]=c;
            }
            else
            {
                int c= d2.genes[i];
                genes[i]= c;
            }
        }
    }
    public void Mutate()
    {
        genes[Random.Range(0,dnalenght)]= Random.Range(0,maxValues);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
