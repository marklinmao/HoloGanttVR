using UnityEngine;


namespace HoloGanttVR
{
    public class HoloGanttLoader : MonoBehaviour
    {

        public float memberPanelGap = 0.5f;
        public float taskPanelGap = 0.5f;

        void Awake()
        {
            //prepare the test data
            //TODO: tobe converted from JSON data
            Project project = PrepTestData();

            //1. init time panel
            GameObject timePanel = Instantiate(Resources.Load("TimePanel")) as GameObject;
            TimePanelLoader tpLoader = timePanel.GetComponent<TimePanelLoader>();
            tpLoader.Load(project);
            timePanel.SetActive(true);

            //2. init member panels
            for(int i = 0; i < project.GetMembers().Count; i ++)
            {
                
            }

            //3. init task panels


        }

        void Start()
        {

        }


        void Update()
        {

        }

        private Project PrepTestData()
        {
            Member m1 = new Member("XiHU", "Hu Xi");
            Member m2 = new Member("MaoLIN", "Lin Mao");
            Member m3 = new Member("YuyanJING", "Jing Yuyan");

            Task tg1t1 = new Task("TG1T1", "Requirement Analysis for Feature 1", m1, Utils.ConvertDateTime("2018-09-24"), Utils.ConvertDateTime("2018-09-28"));
            Task tg1t2 = new Task("TG1T2", "Development for Feature 1", m2, Utils.ConvertDateTime("2018-10-01"), Utils.ConvertDateTime("2018-10-12"));
            Task tg1t3 = new Task("TG1T3", "Testing for Feature 1", m3, Utils.ConvertDateTime("2018-10-15"), Utils.ConvertDateTime("2018-10-19"));
            TaskGroup tg1 = new TaskGroup("TG1", "Feature 1");
            tg1.AddTask(tg1t1);
            tg1.AddTask(tg1t2);
            tg1.AddTask(tg1t3);

            Task tg2t1 = new Task("TG2T1", "Requirement Analysis for Feature 2", m1, Utils.ConvertDateTime("2018-10-01"), Utils.ConvertDateTime("2018-10-05"));
            Task tg2t2 = new Task("TG2T2", "Development phase 1 for Feature 2", m2, Utils.ConvertDateTime("2018-10-08"), Utils.ConvertDateTime("2018-10-12"));
            Task tg2t3 = new Task("TG2T3", "Development phase 2 for Feature 2", m3, Utils.ConvertDateTime("2018-10-15"), Utils.ConvertDateTime("2018-10-26"));
            Task tg2t4 = new Task("TG2T4", "Testing for Feature 2", m1, Utils.ConvertDateTime("2018-10-29"), Utils.ConvertDateTime("2018-11-02"));
            TaskGroup tg2 = new TaskGroup("TG2", "Feature 2");
            tg2.AddTask(tg2t1);
            tg2.AddTask(tg2t2);
            tg2.AddTask(tg2t3);
            tg2.AddTask(tg2t4);

            Project p = new Project("P1", "Project HoloGanttVR");
            p.AddTaskGroup(tg1);
            p.AddTaskGroup(tg2);

            return p;
        }
    }

}

