using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		instance = this;
	}

	public GameObject effectsForBuildings;
	public GameObject effectForSelling;

	private TurretBlueprint BuildingAturret;
	private Node NodeThatSelected;

	public NodeUI nodeUI;

	public bool IsBuildPossible { get { return BuildingAturret != null; } }
	public bool IsMoneyEnough { get { return PlayerStats.Money >= BuildingAturret.cost; } }

	public void NodeSelected (Node node)
	{
		if (NodeThatSelected == node)
		{
			NodeThatDeselected();
			return;
		}

		NodeThatSelected = node;
		BuildingAturret = null;

		nodeUI.SetTarget(node);
	}

	public void NodeThatDeselected()
	{
		NodeThatSelected = null;
		nodeUI.Hide();
	}

	public void SelectingAturretToBuild (TurretBlueprint turret)
	{
		BuildingAturret = turret;
		NodeThatDeselected();
	}

	public TurretBlueprint GettingAturretToBuild ()
	{
		return BuildingAturret;
	}

}
