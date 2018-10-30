using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoloGanttVR
{
    public class TimePanelLoader : MonoBehaviour
    {
        public GameObject titleTextObj;
        public GameObject rulerPanelObj;
        public GameObject backPanelObj;
        public GameObject gridLineObj;

        private Project project;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Load(Project project)
        {
            this.project = project;

            //set title
            this.titleTextObj.GetComponent<Text>().text = project.GetName();

            //init the first grid
            this.gridLineObj.gameObject.SetActive(true);
            Vector3[] posArr = new Vector3[2];
            posArr[0] = new Vector3(-0.5f, -0.5f, -0.25f);
            posArr[1] = new Vector3(-0.5f, 0.5f, -0.25f);
            this.gridLineObj.GetComponent<LineRenderer>().SetPositions(posArr);

            //clone for other grids
            float deltaX = 1f / (float)project.GetDuration();
            for(int i = 1; i <= project.GetDuration(); i ++)
            {
                GameObject clonedGridLine = Instantiate(gridLineObj, this.backPanelObj.transform) as GameObject;
                clonedGridLine.transform.localPosition = new Vector3(deltaX * i, 0, -0.25f);
            }
        }
    }
}

